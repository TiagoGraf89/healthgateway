FROM docker-registry.default.svc:5000/q6qfzk-tools/dotnet22-base:latest
COPY . .
RUN npm install

CMD ["npm", "test", "--", "--baseUrl", "${URL}", "--server", "${SERVER}"]