### ParseLogFile Challenge

Esse projeto foi um desafio da Agile Content que consiste em um microservice com nome de 'iTaaS'(bem micro mesmo) que converta um arquivo de log  de uma CDN  desse formato:
```
312|200|HIT|"GET /robots.txt HTTP/1.1"|100.2
101|200|MISS|"POST /myImages HTTP/1.1"|319.4
199|404|MISS|"GET /not-found HTTP/1.1"|142.9
312|200|INVALIDATE|"GET /robots.txt HTTP/1.1"|245.1
```

Para esse formato:
```
#Version: 1.0
#Date: 15/12/2017 23:01:06
#Fields: provider http-method status-code uri-path time-taken
response-size cache-status
"MINHA CDN" GET 200 /robots.txt 100 312 HIT
"MINHA CDN" POST 200 /myImages 319 101 MISS
"MINHA CDN" GET 404 /not-found 143 199 MISS
"MINHA CDN" GET 200 /robots.txt 245 312 REFRESH_HIT
```
Considerando SOLID e Testes unitários.

### Também faz parte do desafio, que o executável receba 2 parametros:
1. Url da CDN com o Log de origem:
```
https://s3.amazonaws.com/uux-itaas-static/minha-cdn-logs/input-01.txt
```
2. Path para output do arquivo convertido.
```
./output/minhaCdn1.txt
```