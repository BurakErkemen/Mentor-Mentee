# 1) HTTP Metotları
Veri iletimi için kullanılan http, protokollerinden bir tanesidir. WEB tarayıcılar ve sunucular arasındaki iletişime yönelik bazı metotları bulunmaktadır. 

## 1.1)Idempotent Metot 
Bir isteğin birden fazla kez gerçekleşmesi sonucu değiştirmemesi prensibine dayanır. HTTP metotlarında birden fazla kez gönderilen isteğin kaynak üzerinde bir değişikliğe sebebiyet vermemesi durumudur.

## 1.2)GET
Belirtilen bir URI (Uniform Resource Identifier) -Tekdüzen Kaynak Tanımlayıcısı- üzerinden bilgi almak için kullanılan en yayın yöntemlerden biridir. Sunucudan veriyi çekmek için gönderilen tarayıcı isteğidir. Genellikle URL ile birlikte kullanılır ve sorgu metinleri URL içinde gönderilebilir. 
GET metotu bir kaynağı alma isteğidir. idempotent metottur. Aynı kaynağı birden fazla almak kaynak üzerinde bir değişikliğe sebep olmaz.

## 1.3) POST
Sunucuya yeni bir veri kaynağı yazmada kullanılır. Genellikle HTTP body kısmında gönderilir. Bu gönderim ile genellikle form gönderimi ve veri tabanı işlemlerine uygundur. Güvenlik olarak daha sıkı bir metottur. 

## 1.4) PUT
Belirtilen URL üzerindeki kaynağın bir kısmını veya tamamını güncellemek için kullanılabilir. Yani sunucu tarafından kaynağın tamamen değiştirilmesi anlamına gelir. RESTful API’de kullanılabilir. Güncellenecek kaynağın ID’si gönderilmek zorundadır. Idempotent metottur. Belirtilen kaynak her zaman istenilen duruma gelerek değişmezliğini koruyacaktır. 

## 1.5) DELETE
Belirtilen kaynağı kaldırmak için kullanılır. Idempotent metottur. Belirtilen kaynak silinmişse metot kaynak üzerindeki etkisi aynı olarak kalacaktır. 

## 1.6) PATCH
Belirtilen kaynağın bir kısmını değiştirmeyi sağlar. PUT ile farklı olarak sadece değişim istenen alanlar gönderilir, tamamı değiştirilmez. 

## 1.7) OPTIONS
Sunucunun belirli bir kaynağa erişim izinlerini ve desteklediği HTTP metotlarını bildirmek için kullanılır. İstemcinin kaynağa ulaşmadan önce hangi HTTP metotlarını kullanabileceğini ve ek özel başlıkları kullanabileceği sorgulanır. CORS uygulamalarında sıklıkla kullanılır. 

CORS uygulamaları web tarayıcıları arasında güvenli bir şekilde kaynak paylaşımını sağlayan mekanizmadır. İki farklı web sayfası arasında tarayıcı güvenlik politikaları nedeniyle doğrudan kaynak paylaşımı engellenebilir. CORS ile bu engel kaldırılabilir ve site tarafından izin verilebilir. 

## 1.8)HEAD
Belirtilen bir kaynağın sadece header kısmını alıp gerçek içeriği almaz. GET metodu ile aynı özellikleri taşır fakat GET metodundan önce kaynağın varlığını kontrol eder. 

## 1.9) TRACE
Sunucuya gelen istek mesajının içeriği kontrol edilir. Aralarında başka bir sunucu var mı? Var ise mesaj içeriğinde nasıl değişiklikler yaptı? Sorularını cevaplar. Teşhis metodudur. 

## 1.10) SEARCH
Bir dizinin altındaki kaynakları sorgulama işleminde kullanılır. 

## 1.11) CONNECT
Bir Proxy sunucusu üzerinden başka bir sunucuya bağlanmada ve Proxy sunucusunu tünel olarak kullanmada kullanılır. 



# 2) API
API (Application Programming Interface) uygulamaların veya cihazların birbirine nasıl bağlanacağını ve birbirleriyle nasıl iletişim kurabileceğini tanımlayan bir dizi kuraldır. 
API entegrasyonu veri işlemleri ve ortak işlev gerçekleştirmek için API’leri aracılığı ile birbirine bağlanan ve iki veya daha fazla uygulama arasında etkileşimi sağlamayı ifade eder. 

## 2.1) REST 
REST bir sistemde çalışmak için gerekli olan tek şey URL’dir. Bir URL’e istek atıldığında geri dönüş olarak JSON veya XML formatında cevap alınır. Bu cevap parse edilir ve entegrasyon tamamlanır. 
Client uygulama, REST bir servisin detaylarını ve yapısını bilmek zorunda değildir. REST servisler, client-server arasındaki ayrımı baz alır. Bu sayede farklı sunucular ve clientler ile iletişim kurmayı kolaylaştırır. 

## 2.2) REST Tasarım İlkeleri
REST API’nın tasarım ilkeleri kısıttan daha fazla olarak REST mimarisinin hangi sınırlar arasında olduğuna yönelik ilkelerdir.

### 2.2.1) Client (İstemci)
API’yi kullanan yazılım veya kişidir. Bir sayfanın API’sine istek atarak oradan istenilen verileri alan ve yansıtan uygulamalara denir. 

### 2.2.2) Server (Sunucu)
Tüm API ve işlevsellikleri üzerinde barındıran sistemdir. İstemciden gelen istekleri işlemek ve istenilen formatta döndürmekle sorumludur. 

### 2.2.3) Resource (Kaynak)

Kaynak, API’nin herhangi bir bilgi sağlayacağı nesnedir. Bu nesneler belirsiz bir tanımlayıcısı (Unique Identifier) veya numarası vardır.

### 2.2.4) Stateless (Statüsüz)

Sunucunun istekler hakkında bilgi tutmamasıdır. Sunucu istek gönderen client’in kaç istek  veya neler istediği durumları hakkında bilgileri tutmaz. Client ise sunucunun ihtiyaç duyduğu tüm bilgileri verir.

Sunucu, istemci bilgileri tutmadığı için her istekte istemcinin bilgileri vermesi maliyeti arttırır.

### 2.2.5) Uniform Interface (Tekdüze Arayüz)

Client, kaynakları tanımlamak ve etkileşim kurmak için genel bir arayüz kullanmalıdır. Bu, servislerin değişikliklere karşı daha esnek ve ölçeklenebilir olmasını sağlar.

### 2.2.6) Cacheable (Önbelleklenebilir)

Durum bilgisine sahip olmayan bir API, gelen giden istekleri yöneterek istek yükünü arttırabilir. Bunun önüne geçebilmek için önbelleğe isteklerin alınmasıyla daha sonra gelen benzer isteklerin yanıtlanması sağlanır. Bu ilkeye göre yanıttaki veriler dolaylı veya direkt olarak cacheable veya uncacheable olarak tanımlanır.

### 2.2.7) Client-Server

Client ve server bağımsız hareket eder. Server sadece clientten istek gelmesini bekler. Kendi başına bilgi gönderimi yapmaz. Bunun sonucunda client ve server ayrı olarak geliştirilir.

Server tarafından geliştirme bağımsız ve ölçeklenebilirlik, client tarafında ise kodun taşınılabilirliği yüksek olur.

### 2.2.8) Layered System (Katmanlı Sistem)

Client-System mimarisinde bahsedilen doğrudan iletişim olması değil, arada güvenlik katmanları oluşturulmasıdır. Bu katmanlar Request-Response etki etmemelidir. Her katman iletişime geçtiği katmanı bilmelidir.

Ağdaki katmanlı yapı sonucunda, sistemin ölçeklenebilirliği ve esnekliğini arttırır.


### 2.2.9) Code On Demand (Talep Üzerine Kod)

Client, serverdan dinamik olarak kod alabilmesini sağlar. İlke sonucunda, sunucudan istemciye belirli bir bölümün işlenebilmesi için gerekli kod parçacığı veya senaryoları gönderimine izin verir. 

Bu ilke, istemcilerin daha az kod ile daha zengin bir içerik içermesini sağlar. Ancak RESTful servisler genellikle statik kaynaklar döndürür ve stateless olması gerektiği için bu prensip çok yayın olarak kullanılmaz. RESTful servislerde ek işlevsellik veya özel durumlar için kullanılır.

# 3) REST – RESTful Arasındaki Fark

REST, web tabanlı bir tasarım mimarisidir. Kaynaklara benzersiz URI’ler ile erişime ve kaynakların temsilini kullanarak etkileşimde bulunma fikridir. Bu etkileşimler genellikle HTTP metotları kullanılarak gerçekleştirilir.
RESTful, bir uygulamanın veya servisin REST prensiplerini takip etmesi durumudur.
Kaynaklara benzersiz URI’ler üzerinden erişilebilir, HTTP metotlarının kullanıldığı, temsilin istemcilerle paylaşıldığı ve sunucunun durum bilgisinin saklanmadığı anlamına gelir.

# 4) REST API Çalışma Mantığı

Resource ile yapılır. Resource URI ile tenımlanır ve metotlar yardımıyla yapılan istekler sonucu JSON, XML, TXT veya HTML gibi istenilen formatlarında değer döndürülür.  Genellikle JSON tercih edilir. URI ise bir kaynağın web üzerindeki tanımlayıcı adıdır.  

İki çeşittir. 
-	Collection URI: array, list gibi veri türleri için kullanılır. 	
-	Element URI: değişkenler üzerinde işlem yapmak için kullanılır. 

# 5) REST’te HTTP Metotları
## 5.1) GET
URI’de bulunan resource’u getirmek için kullanılır. Bu istekte body olmaz sadece header olur. 
## 5.2) HEAD
Response’ta gönderilecek header’lar için yapılır. Resource’un belirtilen URI’de olmasını veya değişikliklerin en son ne zaman yapıldığı kontrol edilebilir. 
Gönderilen istekte body olmayacak fakat headerlar görünecek.

## 5.3) POST

İstek gönderilecek server’da yeni bir resource oluşturmak, form inputları ve controller resource’ları için kullanılır.
Bu işlemlerde yeni bir post oluşturulacağı için body ve title değişkenleri de gönderilir. 

## 5.4) PUT
Body ile bir resource gönderilir. Eğer URI var olan bir resource’a aitse o resource güncellenir. 

## 5.5) OPTIONS
İstek gönderdiğimiz URI’ın hangi metotları desteklediğini öğrenmek için kullanırız. Bu bilgi bize header’da allow ile verilir. 

# 5.6) RESPONSE Kodları 
Gönderilen isteklerin durumlarını client üzerinde gösteren kodlardır. 
- 1xx bilgi,
- 2xx Başarılı,
- 3xx Yönlendirme,
- 4xx Client Hatası,
-  5xx Server Hatası 
