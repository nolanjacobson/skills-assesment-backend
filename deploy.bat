docker build -t new-nurse-2-nurse-api-img .

docker tag new-nurse-2-nurse-api-img registry.heroku.com/new-nurse-2-nurse-api/web

docker push registry.heroku.com/new-nurse-2-nurse-api/web

heroku container:release web -a new-nurse-2-nurse-api