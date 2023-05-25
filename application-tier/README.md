## criando ambiente virtual python
sudo apt-get install python3-venv
### criar o ambiente isolado no diretório atual
python3 -m venv .

## run project
. ./bin/activate
python3 -m pip install -r requirements.txt
python3 main.py
