# RabbitMQ Genel Bilgi

### Proje Bilgisi
RabbitMq ile mail istemcisinden mail sunucusuna, mail bilgisini göndererek, mail sunucusunun mail gönderim işlemi yapması sağlandı.

### Mantık
Publisher veriyi direk olarak queue'ya değil exchange üzerinden iletir. Publisher, queue'yi bilmemektedir. Mesaj exchange üzerinden routing keye göre queue'ya iletilir. Ardından sırasıyla Consumer'e iletilir.

### RabbitMQ Terimleri

- Producer(Publisher) : Mesajı oluşturan ve gönderen kısım.

- Consumer : Abone olduğu queue'dan veriyi alan ve işleyen taraf.

- Queue : Mesajın sırayla eklendiği ve Consumer tarafından sırayla alınan kuyruk.

- Exchange : Mesajların hangi kuyruklara ne şekilde iletileceğini yöneten kısım.

- Binding : Exchange ve Queue arasındaki bağlantı.

- Routing Key : Exchange'deki mesajın hangi kuyruğa gideceğini belirten anahtar.

- Exchange Type : Gelen Mesajların Routing Key'e göre hangi queue'ye gideceğini belirtir.

### Exchange Type

- Direct : Paket routing key'e göre sadece ilgili kuyruğa gönderilir. 

- Fanout : Routing key’in bir önemi yok. Daha çok broadcast yayınlar için uygundur. Paket tüm kuyruklara iletilir.

- Topic : Paketin bir veya daha çok kuyruğa eklenmesi için kullanılır. 
	- (*) Bir kelimenin yerini alır.
	- (#) Sıfır veya daha fazla kelimenin yerini alır.
> Örneğin; insan.kadın ve insan.erkek şeklinde ayrılmış iki kuyruk olsun. " insan.* " şeklinde gönderim yapıldığında iki kuyruğa da eklenecektir.

- Headers : Paket routing key'e göre değil message headers'daki tipe göre ilgili kuyruğa iletilir.


### Queue Özellikleri

- Name : Tanımlanan kuyruk adı.

- Durable : Verilerin bellekte ya da diskte tutulması. True olarak set edildiğinde persistence, yani diskte tutulmasını belirtir. False in-memory seklinde bellekte tutulmasını sağlar. Broker restart edilirse bellek durumunda bekletilen kuyruk kaybolacaktır.

- Exclusive : Kuyruğun başka connectionlarla birlikte kullanılıp kullanılmaması durumudur. Yalnızca bir bağlantı tarafından kullanılır ve bu bağlantı kapandığında kuyruk silinir. Özel olarak işaretlenirse silinmez.

- AutoDelete : en son bir abonelik iptal edildiğinde en az bir müşteriye sahip olan kuyruk silinir

- Arguments : isteğe bağlı; eklentiler tarafından ve broker'ın özelilikleri; TTL, kuyruk uzunluğu limiti, vb. olarak kullanılır.
