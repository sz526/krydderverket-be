# Krydderverket - 后端开发备忘录

## 1. 项目基础信息
- **技术栈**：.NET API + Entity Framework Core + SQL Server
- **当前联调方式**：Ngrok 内网穿透

## 2. 数据结构 (Product Model)
- Id (int, 主键自增)
- Name (string), Price (decimal), Stock (int)
- Category (string), Description (string), ImageUrl (string)

## 3. 核心配置与避坑指南
- **CORS 跨域**：已在 `Program.cs` 开启 "AllowAll" 策略。
- **Ngrok 报错**：如果前端遇到 CORS/浏览器警告，需要在请求头中加入 `'ngrok-skip-browser-warning': 'true'`。
- **GitHub 提交**：使用 `gh repo create` 命令行工具管理。