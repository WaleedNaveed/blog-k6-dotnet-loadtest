import http from 'k6/http';
import { check, sleep } from 'k6';

export const options = {
    vus: 100,
    duration: '60s',
};

export default function () {
    const res = http.get('https://localhost:7061/api/Product/public');

    check(res, {
        'status is 200': (r) => r.status === 200,
    });

    sleep(1);
}
