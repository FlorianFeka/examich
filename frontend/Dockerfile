FROM node:16-alpine as node
WORKDIR /webapp
COPY package.json .
RUN npm install
COPY . ./
RUN npm run build --prod
RUN ls
RUN pwd

FROM nginx:alpine
COPY nginx.conf /etc/nginx/conf.d/default.conf
COPY --from=node /webapp/dist/examich /usr/share/nginx/html
EXPOSE 80
