dab init --database-type "mssql" --host-mode "Development" --connection-string "Server=localhost,1433;User Id=sa;Database=IntelliBlog_Dev;Password=G7i5z5mo;TrustServerCertificate=True;Encrypt=True;"

dab add Blogs --source "dbo.Blogs" --permissions "anonymous:*"
dab add Articles --source "dbo.Articles" --permissions "anonymous:*"
dab add Sources --source "dbo.Sources" --permissions "anonymous:*"