import http from 'k6/http';
import { check, sleep } from 'k6';

// Replace this with an actual token copied from login response
const token = '';

export const options = {
    vus: 100,
    duration: '60s',
};

export default function () {
    const secureParams = {
        headers: {
            Authorization: `Bearer ${token}`,
        },
    };

    const res = http.get('https://localhost:7061/api/Product/secure?id=1', secureParams);

    check(res, {
        'status is 200': (r) => r.status === 200,
    });

    sleep(1);
}
