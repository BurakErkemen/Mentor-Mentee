<h1> HTTP Metotları</h1>
Veri iletimi için kullanılan http, protokollerinden bir tanesidir. WEB tarayıcılar ve sunucular arasındaki iletişime yönelik bazı metotları bulunmaktadır. 
<h2>1.Idempotent Metot</h2> 
Bir isteğin birden fazla kez gerçekleşmesi sonucu değiştirmemesi prensibine dayanır. HTTP metotlarında birden fazla kez gönderilen isteğin kaynak üzerinde bir değişikliğe sebebiyet vermemesi durumudur.
<h2>2.GET</h2>
Belirtilen bir URI (Uniform Resource Identifier) -Tekdüzen Kaynak Tanımlayıcısı- üzerinden bilgi almak için kullanılan en yayın yöntemlerden biridir. Sunucudan veriyi çekmek için gönderilen tarayıcı isteğidir. Genellikle URL ile birlikte kullanılır ve sorgu metinleri URL içinde gönderilebilir. 

GET metotu bir kaynağı alma isteğidir. idempotent metottur. Aynı kaynağı birden fazla almak kaynak üzerinde bir değişikliğe sebep olmaz.
<h2>3.POST</h2>
Sunucuya yeni bir veri kaynağı yazmada kullanılır. Genellikle HTTP body kısmında gönderilir. Bu gönderim ile genellikle form gönderimi ve veri tabanı işlemlerine uygundur. Güvenlik olarak daha sıkı bir metottur. 
<h2>4.PUT</h2>
Belirtilen URL üzerindeki kaynağın bir kısmını veya tamamını güncellemek için kullanılabilir. Yani sunucu tarafından kaynağın tamamen değiştirilmesi anlamına gelir. RESTful API’de kullanılabilir. Güncellenecek kaynağın ID’si gönderilmek zorundadır. Idempotent metottur. Belirtilen kaynak her zaman istenilen duruma gelerek değişmezliğini koruyacaktır. 
<h2>5.DELETE</h2>
Belirtilen kaynağı kaldırmak için kullanılır. Idempotent metottur. Belirtilen kaynak silinmişse metot kaynak üzerindeki etkisi aynı olarak kalacaktır. 
<h2>6.PATCH</h2>
Belirtilen kaynağın bir kısmını değiştirmeyi sağlar. PUT ile farklı olarak sadece değişim istenen alanlar gönderilir, tamamı değiştirilmez. 
<h2>7.OPTIONS</h2>
Sunucunun belirli bir kaynağa erişim izinlerini ve desteklediği HTTP metotlarını bildirmek için kullanılır. İstemcinin kaynağa ulaşmadan önce hangi HTTP metotlarını kullanabileceğini ve ek özel başlıkları kullanabileceği sorgulanır. CORS uygulamalarında sıklıkla kullanılır. 
CORS uygulamaları web tarayıcıları arasında güvenli bir şekilde kaynak paylaşımını sağlayan mekanizmadır. İki farklı web sayfası arasında tarayıcı güvenlik politikaları nedeniyle doğrudan kaynak paylaşımı engellenebilir. CORS ile bu engel kaldırılabilir ve site tarafından izin verilebilir. 
<h2>8.HEAD</h2>
Belirtilen bir kaynağın sadece header kısmını alıp gerçek içeriği almaz. GET metodu ile aynı özellikleri taşır fakat GET metodundan önce kaynağın varlığını kontrol eder. 
<h2>9.TRACE</h2>
Sunucuya gelen istek mesajının içeriği kontrol edilir. Aralarında başka bir sunucu var mı? Var ise mesaj içeriğinde nasıl değişiklikler yaptı? Sorularını cevaplar. Teşhis metodudur. 
<h2>10.SEARCH</h2>
Bir dizinin altındaki kaynakları sorgulama işleminde kullanılır. 
<h2>11.CONNECT</h2>
Bir Proxy sunucusu üzerinden başka bir sunucuya bağlanmada ve Proxy sunucusunu tünel olarak kullanmada kullanılır. 
 
<h1>API</h1>
API (Application Programming Interface) uygulamaların veya cihazların birbirine nasıl bağlanacağını ve birbirleriyle nasıl iletişim kurabileceğini tanımlayan bir dizi kuraldır. 
API entegrasyonu veri işlemleri ve ortak işlev gerçekleştirmek için API’leri aracılığı ile birbirine bağlanan ve iki veya daha fazla uygulama arasında etkileşimi sağlamayı ifade eder. 
<h2>REST</h2>h2> 
REST bir sistemde çalışmak için gerekli olan tek şey URL’dir. Bir URL’e istek atıldığında geri dönüş olarak JSON veya XML formatında cevap alınır. Bu cevap parse edilir ve entegrasyon tamamlanır. 
Client uygulama, REST bir servisin detaylarını ve yapısını bilmek zorunda değildir. REST servisler, client-server arasındaki ayrımı baz alır. Bu sayede farklı sunucular ve clientler ile iletişim kurmayı kolaylaştırır. 
<h2>REST Tasarım İlkeleri</h2>
REST API’nın tasarım ilkeleri kısıttan daha fazla olarak REST mimarisinin hangi sınırlar arasında olduğuna yönelik ilkelerdir.
<h3>Client (İstemci)</h3>
API’yi kullanan yazılım veya kişidir. Bir sayfanın API’sine istek atarak oradan istenilen verileri alan ve yansıtan uygulamalara denir. 
<h3>Server (Sunucu)</h3>
Tüm API ve işlevsellikleri üzerinde barındıran sistemdir. İstemciden gelen istekleri işlemek ve istenilen formatta döndürmekle sorumludur. 
<h3>Resource (Kaynak)</h3>
Kaynak, API’nin herhangi bir bilgi sağlayacağı nesnedir. Bu nesneler belirsiz bir tanımlayıcısı (Unique Identifier) veya numarası vardır.  
<h3>Stateless (Statüsüz)</h3>
Sunucunun istekler hakkında bilgi tutmamasıdır. Sunucu istek gönderen client’in kaç istek  veya neler istediği durumları hakkında bilgileri tutmaz. Client ise sunucunun ihtiyaç duyduğu tüm bilgileri verir. 
Sunucu, istemci bilgileri tutmadığı için her istekte istemcinin bilgileri vermesi maliyeti arttırır. 
<h3>Uniform Interface (Tekdüze Arayüz)</h3>
Client, kaynakları tanımlamak ve etkileşim kurmak için genel bir arayüz kullanmalıdır. Bu, servislerin değişikliklere karşı daha esnek ve ölçeklenebilir olmasını sağlar.
<h3>Cacheable (Önbelleklenebilir)</h3>
Durum bilgisine sahip olmayan bir API, gelen giden istekleri yöneterek istek yükünü arttırabilir. Bunun önüne geçebilmek için önbelleğe isteklerin alınmasıyla daha sonra gelen benzer isteklerin yanıtlanması sağlanır. Bu ilkeye göre yanıttaki veriler dolaylı veya direkt olarak cacheable veya uncacheable olarak tanımlanır.
<h3>Client-Server </h3>
Client ve server bağımsız hareket eder. Server sadece clientten istek gelmesini bekler. Kendi başına bilgi gönderimi yapmaz. Bunun sonucunda client ve server ayrı olarak geliştirilir. 
Server tarafından geliştirme bağımsız ve ölçeklenebilirlik, client tarafında ise kodun taşınılabilirliği yüksek olur.
<h3>Layered System (Katmanlı Sistem)</h3>
Client-System mimarisinde bahsedilen doğrudan iletişim olması değil, arada güvenlik katmanları oluşturulmasıdır. Bu katmanlar Request-Response etki etmemelidir. Her katman iletişime geçtiği katmanı bilmelidir. 
Ağdaki katmanlı yapı sonucunda, sistemin ölçeklenebilirliği ve esnekliğini arttırır. 
<h3>Code On Demand (Talep Üzerine Kod)</h3>
Client, serverdan dinamik olarak kod alabilmesini sağlar. İlke sonucunda, sunucudan istemciye belirli bir bölümün işlenebilmesi için gerekli kod parçacığı veya senaryoları gönderimine izin verir. 
Bu ilke, istemcilerin daha az kod ile daha zengin bir içerik içermesini sağlar. Ancak RESTful servisler genellikle statik kaynaklar döndürür ve stateless olması gerektiği için bu prensip çok yayın olarak kullanılmaz. RESTful servislerde ek işlevsellik veya özel durumlar için kullanılır. 
 
<h1>REST – RESTful Arasındaki Fark</h1>
REST, web tabanlı bir tasarım mimarisidir. Kaynaklara benzersiz URI’ler ile erişime ve kaynakların temsilini kullanarak etkileşimde bulunma fikridir. Bu etkileşimler genellikle HTTP metotları kullanılarak gerçekleştirilir. 
RESTful, bir uygulamanın veya servisin REST prensiplerini takip etmesi durumudur. 
Kaynaklara benzersiz URI’ler üzerinden erişilebilir, HTTP metotlarının kullanıldığı, temsilin istemcilerle paylaşıldığı ve sunucunun durum bilgisinin saklanmadığı anlamına gelir.

