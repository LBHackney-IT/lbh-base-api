FROM ruby:2.5.0

ARG RAILS_ENV=development
WORKDIR /app

ENV RAILS_ENV ${RAILS_ENV}

COPY Gemfile Gemfile.lock ./
RUN bundle check || bundle install

COPY . /app
EXPOSE 3000

CMD ["sh", "-c", "rails db:migrate ; rails s"]