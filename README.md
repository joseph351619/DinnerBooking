DinnerBooking

執行方式：在Package Manager Console將Default project選到DinnerBooking.Data執行指令update-database，目前Server設為local。

錯誤處理：如果出現遺失bin\roslyn\csc.exe，請更新Microsoft.CodeDom.Providers.DotNetCompilerPlatform這個組件。

大略說明：
本來是架構是Repository/Service/View，
但後來考量到物件的狀態會跟view直接相關，
所以把Service改成Core讓物件的狀態直接傳給View，
主要邏輯在Shop內並由其呼叫其他物件，
在controller初始化後會初始化shop並把cart放入，
然後將Email註冊到afterBooking在完成訂購後寄信。

注意事項：目前是由gmail充當smtp server，請寄信不要過於頻繁，之前有其他信箱被鎖。
