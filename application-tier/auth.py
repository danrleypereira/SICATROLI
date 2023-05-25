from functools import wraps
from flask import request, jsonify

def authenticate_reader_token(f):
    @wraps(f)
    def decorated_function(*args, **kwargs):
        token = None

        if 'Authorization' in request.headers:
            auth_header = request.headers['Authorization']
            token = auth_header.split(' ')[1] if len(auth_header.split(' ')) > 1 else None

        if not token:
            return jsonify({'message': 'Missing authorization token'}), 401

        # Perform token validation
        # You can verify the token against your user database or any other authentication mechanism
        """
          - Token existe no banco?
          - - Mandar requisição para a Data Tier
        """

        

        # Example token validation
        if token != 'your_secret_token':
            return jsonify({'message': 'Invalid token'}), 401 

        return f(*args, **kwargs)

    return decorated_function

def authenticate_institution_token(f):
    @wraps(f)
    def decorated_function(*args, **kwargs):
        token = None

        if 'Authorization' in request.headers:
            auth_header = request.headers['Authorization']
            token = auth_header.split(' ')[1] if len(auth_header.split(' ')) > 1 else None

        if not token:
            return jsonify({'message': 'Missing authorization token'}), 401

        # Perform token validation
        # You can verify the token against your user database or any other authentication mechanism
        """
          - Token existe no banco?
          - - Mandar requisição para a Data Tier
        """

        

        # Example token validation
        if token != 'your_secret_token':
            return jsonify({'message': 'Invalid token'}), 401 

        return f(*args, **kwargs)

    return decorated_function