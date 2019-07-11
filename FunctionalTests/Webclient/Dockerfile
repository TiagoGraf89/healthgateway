FROM node:10.16.0
COPY . .
RUN npm install

CMD ["npm", "test", "--", "--baseUrl", "${URL}", "--server", "${SERVER}"]