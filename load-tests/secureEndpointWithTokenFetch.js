import http from 'k6/http';
import { check, sleep } from 'k6';

export const options = {
    vus: 100,
    duration: '60s',
};

// Setup: Run once, fetch token
export function setup() {
    const loginPayload = JSON.stringify({
        username: 'admin@example.com',
        password: '123456',
    });

    const loginHeaders = {
        headers: { 'Content-Type': 'application/json' },
    };

    const res = http.post('https://localhost:7061/api/Auth/login', loginPayload, loginHeaders);

    const token = res.json().result.token; 

    return token;
}

// Test: Run per VU, using token
export default function (token) {
    const res = http.get('https://localhost:7061/api/Product/secure?id=1', {
        headers: {
            Authorization: `Bearer ${token}`,
        },
    });

    check(res, {
        'is status 200': (r) => r.status === 200,
    });

    sleep(1);
}
