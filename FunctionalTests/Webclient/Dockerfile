#FROM selenium/node-chrome:3.5.3-boron
FROM docker-registry.pathfinder.gov.bc.ca/q6qfzk-tools/dotnet22-base:latest

RUN yum clean all 

RUN yum update -y

RUN yum install wget -y

RUN yum-config-manager --enable rhel-7-server-extras-rpms
# Install Chrome for Selenium
RUN echo "google-chrome-stable_current_x86_64.rpm"
RUN wget https://dl.google.com/linux/direct/google-chrome-stable_current_x86_64.rpm
RUN yum -y install redhat-lsb libXScrnSaver
RUN yum -y localinstall google-chrome-stable_current_x86_64.rpm

# Install chromedriver for Selenium
RUN echo "Downloading 2.35/chromedriver_linux64.zip"
RUN curl -sL https://chromedriver.storage.googleapis.com/2.35/chromedriver_linux64.zip -o /usr/local/bin/chromedriver
RUN chmod +x /usr/local/bin/chromedriver

RUN npm install

CMD ["npm", "test"]