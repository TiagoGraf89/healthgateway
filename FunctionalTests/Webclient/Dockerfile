FROM docker-registry.pathfinder.gov.bc.ca/q6qfzk-tools/dotnet22-base:latest

RUN yum install wget -y

RUN wget https://dl.google.com/linux/direct/google-chrome-stable_current_x86_64.rpm && \
    yum -y install redhat-lsb libXScrnSaver && \
    yum -y localinstall google-chrome-stable_current_x86_64.rpm

# Install Chrome for Selenium
RUN wget https://dl.google.com/linux/direct/google-chrome-stable_current_x86_64.rpm && \
  yum install -y ./google-chrome-stable_current_*.rpm

# Install chromedriver for Selenium
RUN mkdir -p /opt && \
  pushd /opt && \
  echo "Downloading https://chromedriver.storage.googleapis.com/2.31/chromedriver_linux64.zip" && \
  curl -sL https://chromedriver.storage.googleapis.com/2.31/chromedriver_linux64.zip -o /usr/local/bin/chromedriver && \
  chmod +x /usr/local/bin/chromedriver

RUN npm install

CMD ["npm", "test"]