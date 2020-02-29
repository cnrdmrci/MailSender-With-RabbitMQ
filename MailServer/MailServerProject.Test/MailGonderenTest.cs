﻿using System;
using System.Collections.Generic;
using System.Text;
using MailSender.Abstract;
using MailSender.Concrete;
using MailSender.Model;
using Moq;
using NUnit.Framework;

namespace MailServerProject.UnitTest
{
    [TestFixture]
    public class MailGonderenTest
    {
        private Mock<IVeritabaniIslemcisi> _veritabaniIslemcisi;
        private Mock<IMailIslemcisi> _mailIslemcisi;
        private Mock<ISmtpAyarlayan> _smtpAyarlayan;
        private Mock<IMailKontrolcu> _mailKontrolcu;
        private MailGonderen _mailGonderen;
        private MailBilgi _mailBilgi;
        private MailBilgi _mailBilgiHatali;

        [SetUp]
        public void Init()
        {
            _veritabaniIslemcisi = new Mock<IVeritabaniIslemcisi>(MockBehavior.Strict);
            _smtpAyarlayan = new Mock<ISmtpAyarlayan>(MockBehavior.Strict);
            _mailKontrolcu = new Mock<IMailKontrolcu>(MockBehavior.Loose);
            _mailIslemcisi = new Mock<IMailIslemcisi>(MockBehavior.Loose);

            _mailGonderen = new MailGonderen(_mailIslemcisi.Object, _smtpAyarlayan.Object, _veritabaniIslemcisi.Object, _mailKontrolcu.Object);

            _mailBilgi = new MailBilgi()
            {
                GonderilecekEpostaAdresleri = new List<string>() { "caner@adayazilim.com" },
                Konu = "test konu",
                Icerik = "test icerik",
            };

            _mailBilgiHatali = new MailBilgi()
            {
                GonderilecekEpostaAdresleri = new List<string>() { "caneradayazilim.com" },
                Konu = "test konu",
                Icerik = "test icerik"
            };

        }

        [TearDown]
        public void CleanUp()
        { /* .... */ }

        [Test]
        public void PostaGonderilmedenOnce_MailAdresiKontroluYapilir()
        {
            //when
            _mailGonderen.Gonder(_mailBilgiHatali);

            //then
            _mailKontrolcu.Verify(x => x.MailAdresiKontrolEt(_mailBilgiHatali));

        }

        [Test]
        public void PostaGonderilecekMailAdresiHataliysa_BasarisizSonucDoner()
        {
            //given
            _mailKontrolcu.Setup(x => x.MailAdresiKontrolEt(_mailBilgiHatali)).Returns(false);

            //when
            MailGonderimSonuc mailGonderimSonuc = _mailGonderen.Gonder(_mailBilgiHatali);

            //then
            Assert.IsFalse(mailGonderimSonuc.Basarili);
        }

        [Test]
        public void PostaGonderimiBasariliysa_VeritabaninaBasariliKaydetCagirilir()
        {
            //given
            _mailKontrolcu.Setup(x => x.MailAdresiKontrolEt(_mailBilgi)).Returns(true);

            //when
            MailGonderimSonuc mailGonderimSonuc = _mailGonderen.Gonder(_mailBilgi);

            //then
            if (mailGonderimSonuc.Basarili)
                _veritabaniIslemcisi.Verify(x => x.BasariliGonderimKaydet(_mailBilgi));
        }

        [Test]
        public void PostaGonderimiBasariliDegilse_VeritabaninaHataliKaydetCagirilir()
        {
            //given
            _mailKontrolcu.Setup(x => x.MailAdresiKontrolEt(_mailBilgiHatali)).Returns(true);

            //when
            MailGonderimSonuc mailGonderimSonuc = _mailGonderen.Gonder(_mailBilgiHatali);

            //then
            if (!mailGonderimSonuc.Basarili)
                _veritabaniIslemcisi.Verify(x => x.HataliGonderimKaydet(_mailBilgiHatali, It.IsAny<string>()));
        }

        [Test]
        public void PostaGonderimiSirasindaHataAlinirsa_VeritabaninaHataliKaydetCagirilir()
        {
            Exception hata = new Exception();
            //given
            _mailIslemcisi.Setup(x => x.MailGonderimiYap(_mailBilgi, _smtpAyarlayan.Object)).Throws(hata);

            //when
            _mailGonderen.Gonder(_mailBilgi);

            //then
            _veritabaniIslemcisi.Verify(x => x.HataliGonderimKaydet(_mailBilgi, It.IsAny<string>()));
        }
    }
}
