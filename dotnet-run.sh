#!/bin/bash

#!/bin/bash

cd "$(dirname "$0")/backend/Api"

dotnet build
dotnet watch run
