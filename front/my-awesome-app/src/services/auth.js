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
        let token = JSON.parse(localStorage.getItem('token'))
        if (token) {
            return { Authorization: 'Bearer ' + token }
        } else {
            return {}
        }
    }
}