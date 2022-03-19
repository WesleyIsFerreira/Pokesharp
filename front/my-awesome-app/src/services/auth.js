import { http } from './config'
import router from '../router/index.js'

export default {
    login:(parans) => {
        return http.post('api/auth/login', parans)
    },
    logout(){
        localStorage.removeItem('token')
        router.push("/")
    },
    authHeader(){
        const token = localStorage.getItem('token')
        if (token) {
            return { Authorization: token }
        } else {
            return {}
        }
    }
}