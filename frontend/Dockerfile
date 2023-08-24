FROM node:16-alpine
WORKDIR /frontend
COPY package.json ./
RUN npm install --force
COPY ./ ./
ARG REACT_APP_PROXY
ENV REACT_APP_PROXY=${REACT_APP_PROXY}
EXPOSE 3000
CMD npm run start