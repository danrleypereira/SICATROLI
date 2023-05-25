from flask import Flask, request, jsonify
from datetime import datetime
from hashlib import sha256
from flask_cors import CORS
import requests
from auth import authenticate_bearer_token

import os
from dotenv import load_dotenv

load_dotenv()

from sendblue import SendBlue

app = Flask(__name__)
CORS(app)

@app.route('/login', methods=['POST'])
def auth_mail():
    hash = request.args.get('hashId')
    ## verificar se existe hash no banco.
    
    return jsonify({}), 201

@app.route('/trocar-livro', methods=['POST'])
@authenticate_bearer_token
def swap():
    return jsonify({}), 200

if __name__ == '__main__':
    app.run(debug=True, host="0.0.0.0", port=5000)
