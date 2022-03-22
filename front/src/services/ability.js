import { http } from './config'

export default {
    create:(parans) => {
        return http.post('api/auth/login', parans)
    }
}