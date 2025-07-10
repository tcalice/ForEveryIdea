import json
from jose import jwk
from Crypto.PublicKey import RSA

# Generate a new RSA key
key = RSA.generate(2048)

# Create the JWK from the public key, including the Key ID
# A Key ID ('kid') is a unique identifier for your key
public_jwk = jwk.construct(key.publickey(), algorithm='RS256').to_dict()
public_jwk['kid'] = 'my-unique-key-id-1' # Assign a unique Key ID

# A JWKS is a JSON object with a "keys" list
jwks = {'keys': [public_jwk]}

# Save the JWKS to a file
with open('jwks.json', 'w') as f:
        json.dump(jwks, f, indent=4)

print("✅ Successfully generated jwks.json")