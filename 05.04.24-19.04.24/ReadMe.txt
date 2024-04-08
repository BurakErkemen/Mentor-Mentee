<h1>HTTP Metotları</h1>
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
 
<h1>REST Standartları</h1>
