# base image
FROM node:12.18-alpine

# create & set working directory
RUN mkdir -p /usr/src
WORKDIR /usr/src

# copy source files
COPY Vortx.Web/vortx-front/ /usr/src
COPY Vortx.Web/vortx-front/package.json /usr/src

# install dependencies
RUN npm install

# start app
RUN npm run build
EXPOSE 3000
CMD npm run start