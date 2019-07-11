FROM docker-registry.default.svc:5000/q6qfzk-tools/dotnet22-base:latest

RUN yum install npm -y
COPY . .
RUN npm install

CMD ["npm", "test", "--", "--baseUrl", "${URL}", "--server", "${SERVER}"]