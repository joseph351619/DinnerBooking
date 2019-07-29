DinnerBooking

執行方式：在Package Manager Console將Default project選到DinnerBooking.Data執行指令update-database，目前Server設為local。

錯誤處理：如果出現遺失bin\roslyn\csc.exe，請更新Microsoft.CodeDom.Providers.DotNetCompilerPlatform這個組件。

大略說明：
目前剛開始學習前端框架所以主要是以ajax與session的方式實作，
本來是架構是Repository/Service/View，
但考量到想要使用以partial view為主的表現方式，
因為可以使用C#強型別的好處比較好維護，
如果直接顯示partial view物件的狀態會跟view直接相關，
所以把Service改成Core讓物件的狀態直接傳給View，
主要邏輯在Shop內並由其呼叫其他物件，
在controller初始化後會初始化shop並把cart放入，
然後將Email的SendEmail註冊到shop的afterBooking在完成訂購後寄信。


IValidationDictioanry結合MVC的ModelState在Controller與Core層使用，
並且在BaseController結合ModelState的結果、錯誤資訊然後把partial view以html字串的方式傳到前端替換部分畫面。
下圖為目前類別相依狀況
<img src="https://github.com/joseph351619/DinnerBooking/blob/master/IMG_1549.JPG" width="500" height="490">



下圖為各個頁面會使用到的Action，最後確認購買畫面沒有API。
<img src="https://github.com/joseph351619/DinnerBooking/blob/master/IMG_1546.jpg" width="600" height="400">


注意事項：目前是由gmail充當smtp server，請寄信不要過於頻繁，之前有其他信箱被鎖。
