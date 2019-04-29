Param 
( 
    [String]$DBName = ""     #The database connectionstring 
)
$DBNewName = "$($DBName).db"
dotnet user-secrets set "DBName" $DBNewName