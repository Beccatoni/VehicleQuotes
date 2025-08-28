### Docker 
#### If you want to run Postgres manually with a plain container
```shell
docker run --name dbimagename \
  -e POSTGRES_USER=username \
  -e POSTGRES_PASSWORD=password \
  -e POSTGRES_DB=dbname \
  -p 5433:5432 \
  -d postgres: version
```
#### verify if it's running
```shell
docker ps
```

### Migration running
```shell
dotnet ef migrations remove --force
dotnet ef migrations add AddIdentityTables
dotnet ef database update
```


