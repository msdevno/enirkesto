FROM node:latest

WORKDIR /app

ADD package.json /app
ADD dictionary.csv /app
ADD stopwords.txt /app
ADD *.js /app/

RUN ["npm", "install"]

EXPOSE 3000
CMD ["node", "main.js"]