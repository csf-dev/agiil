#!/bin/bash

SERVER_PORT="8080"
SERVER_ADDR="127.0.0.1"
WEB_APP_HOME="Output/Web apps/Agiil.Web"
SERVER_WEB_APP="/:."
SERVER_PID=".xsp4.pid"
APP_HOMEPAGE="http://localhost:8080/Home"
SECONDS_BETWEEN_CONNECT_ATTEMPTS="2"
MAX_ATTEMPTS="5"
FAKE_REGISTRY_DIR="missing_registry_workaround"

app_available=1

start_webserver()
{
  echo "Starting a testing build of Agiil on a web server ..."
  original_dir="$(pwd)"
  
  work_around_missing_registry_dir
  
  cd "./${WEB_APP_HOME}/"
  
  xsp4 \
    --nonstop \
    --verbose \
    --address "$SERVER_ADDR" \
    --port "$SERVER_PORT" \
    --applications "$SERVER_WEB_APP" \
    --pidfile "${original_dir}/${SERVER_PID}" \
    &
  
  cd "$original_dir"
}

work_around_missing_registry_dir()
{
  # OWIN (used by this app) makes use of the .NET Registry API,
  # obviously GNU/Linux-based systems have no registry.
  # There is an equivalent mechanism provided, backed by the filesystem
  # and by default this filesystem is found at either the location
  # MONO_REGISTRY_PATH or (if that is unset) the path /etc/mono/registry
  # 
  # Unfortunately, some distributions leave both that env var unset
  # AND also do not provide the fallback location.  This leads to the
  # OWIN SystemWeb hosting mechanism crashing really early on (before it
  # invokes the startup type), because it can't access the registry.
  # 
  # This workaround detects that scenario and creates a local version
  # of that registry filesystem and then sets the registry path to that
  # location.

  if [ -n "$MONO_REGISTRY_PATH" ]
  then
    # Default location
    MONO_REGISTRY_PATH="/etc/mono/registry"
  fi
  
  if [ ! -d "$MONO_REGISTRY_PATH" ]
  then
    # We need to apply the workaround
    mkdir -p "$FAKE_REGISTRY_DIR"
    export MONO_REGISTRY_PATH="$(readlink -f "$FAKE_REGISTRY_DIR")"
  fi
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
  
  if [ "$app_available" -eq "1" ]
  then
    echo "Connection to the web app was unsuccessful!" >&2
    wget \
    -T 120 \
    --content-on-error \
    -O - \
    "$APP_HOMEPAGE" \
    >&2
  fi
}

try_web_app_connection()
{
  wget \
    -T 120 \
    -q \
    -O - \
    "$APP_HOMEPAGE" \
    >/dev/null
  if [ "$?" -eq "0" ]
  then
    app_available=0
  fi
}

start_webserver
wait_for_app_to_become_available

exit "$app_available"
