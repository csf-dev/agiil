#!/bin/bash

SERVER_PORT="8080"
SERVER_ADDR="127.0.0.1"
SERVER_WEB_APP="/:Agiil.Web/"
WEB_APP_BIN="Agiil.Web/bin"
TESTING_BIN="Tests/Agiil.Web.TestBuild/bin/Debug"
SERVER_PID=".xsp4.pid"
APP_HOMEPAGE="http://localhost:8080/Home"
SECONDS_BETWEEN_CONNECT_ATTEMPTS="2"
MAX_ATTEMPTS="5"

app_available=1

start_webserver()
{
  echo "Starting a testing build of Agiil on a web server ..."
  xsp4 \
    --nonstop \
    --address "$SERVER_ADDR" \
    --port "$SERVER_PORT" \
    --applications "$SERVER_WEB_APP" \
    --pidfile "$SERVER_PID" \
    &
}

wait_for_app_to_become_available()
{
  echo "Waiting for Agiil to become available ..."
  for attempt in $(seq 1 "$MAX_ATTEMPTS")
  do
    sleep "$SECONDS_BETWEEN_CONNECT_ATTEMPTS"
    echo "Connection attempt $attempt of $MAX_ATTEMPTS ..."
    try_web_app_connection
    if [ "$app_available" -eq "0" ]
    then
      echo "Connection successful!"
      break
    fi
  done
}

try_web_app_connection()
{
  wget \
    -T 120 \
    -O - \
    "$APP_HOMEPAGE" \
    >/dev/null
  if [ "$?" -eq "0" ]
  then
    app_available=0
  fi
}

copy_testing_files_to_web_app()
{
  cp "${TESTING_BIN}"/* "$WEB_APP_BIN"
}

copy_testing_files_to_web_app
start_webserver
wait_for_app_to_become_available

exit "$app_available"
