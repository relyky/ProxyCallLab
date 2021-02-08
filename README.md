# Swagger UI Relay Lab
* Swagger UI + WebApi2應用練習。      
* `前台`+`中台(中繼)`+`後台`  
* 可利用Swagger UI工具組織WebApi2的中繼/proxy。

# 二種主流 Swagger UI 技術
## Swashbuckle   
為本來最有名氣的Swagger UI技術。其作者現在已投靠微軟門下。
與Visual Studio 2017/2019 的整合性更佳。但不再更新NetFx的版本，現主要提供`.Net Core 5`的版本。若只需要簡單的client-server通訊，那Swashbuckle可以滿足也夠用。   
功能的部份：可以做`Swagger UI`與`swaggerClient`。  

## NSwag   
現在名氣已反超為第一。現在同時支援NetFx與Net Core 版本。另外功能性也較為"廣大"。若需要更多進階的Swagger UI應用，那就要導入NSwang。   
功能的部份：可以做`Swagger UI`、`CSharp Client`、`TypeScript Client`與`CSharp Controller`。   

# 系統框架

| 用戶 | 前台 | 中台 | 後台 |  
|---|---|---|---| 
| Browser | Frontend Web| Relay Service| Backend Service|  
|ReactApp|CoreWeb + Swagger UI|WebAPI2 + Swagger UI|WebAPI2 + Swagger UI| 
| |NSwag|NSwag|Swashbuckle| 
|axios|CSharp Client, CSharp Controller|CSharp Client, CSharp Controller|| 

# 開發工具與執行環境
* IDE: Visual Studio 2019
* .Net Core 5 + node.js
* Unchase OpenAPI (Swagger) Connected Service
* NSwag Studio

# 工具與模組清單
* Swashbuckle.AspNetCore
* NSwag.AspNetCore
* Unchase OpenAPI (Swagger) Connected Service
* NSwag Studio
