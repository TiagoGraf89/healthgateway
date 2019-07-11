FROM docker-registry.pathfinder.gov.bc.ca/q6qfzk-tools/dotnet22-base:latest
COPY . .
RUN npm install

CMD ["npm", "test", "--", "--baseUrl", "${URL}", "--server", "${SERVER}"]