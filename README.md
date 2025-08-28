### Docker
```
docker run --name dbimagename \
  -e POSTGRES_USER=username \
  -e POSTGRES_PASSWORD=password \
  -e POSTGRES_DB=dbname \
  -p 5433:5432 \
  -d postgres: version
```
