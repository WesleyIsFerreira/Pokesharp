import { http } from './config'

export default {
    login:(parans) => {
        
        return http.post('api/auth/login', parans)
    }
}