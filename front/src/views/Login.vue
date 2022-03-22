<template>
  <div class="bg-cover min-h-screen flex items-center justify-center py-12 px-4 sm:px-6 lg:px-8" style="background-image: url('img/bg.jpg')">
    <div class="max-w-xs w-full space-y-8">
      <div>
        <img class="z-10 mx-auto h-20 w-auto" src="img/pokedex.png" alt="Workflow" />

      </div>
      <form class="mt-8 space-y-6" action="#" method="POST">
        <input type="hidden" name="remember" value="true" />
        <div class="rounded-md shadow-sm -space-y-px">
          <div>
            <label for="user" class="sr-only">User Name</label>
            <input v-model="user" id="user" name="user" type="text" autocomplete="off" required class="appearance-none rounded-none relative block w-full px-3 py-2 border border-gray-300 placeholder-gray-500 text-gray-900 rounded-t-md focus:outline-none focus:ring-indigo-500 focus:border-indigo-500 focus:z-10 sm:text-sm" placeholder="User Name" />
          </div>
          <div>
            <label for="password" class="sr-only">Password</label>
            <input v-model="password" id="password" name="password" type="password" autocomplete="current-password" required="" class="appearance-none rounded-none relative block w-full px-3 py-2 border border-gray-300 placeholder-gray-500 text-gray-900 rounded-b-md focus:outline-none focus:ring-indigo-500 focus:border-indigo-500 focus:z-10 sm:text-sm" placeholder="Password" />
          </div>
        </div>
        <div>
          <button :disabled="loading" @click="logar" type="submit" class="group relative w-1/2 flex justify-center py-2 px-4 border border-transparent text-sm mx-auto font-medium rounded-md text-white bg-indigo-600 hover:bg-indigo-700 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-indigo-500">
            <span class="absolute left-0 inset-y-0 flex items-center pl-3">
              <div v-if="loading" class="flex justify-center items-center">
                <div class="spinner-border animate-spin inline-block w-8 h-8 border-4 rounded-full" role="status">
                  <span class="visually-hidden">Loading...</span>
                </div>
              </div>
              <LockClosedIcon v-else class="h-5 w-5 text-indigo-500 group-hover:text-indigo-400" aria-hidden="true" />
            </span>
            Entrar
          </button>
        </div>
      </form>
    </div>
  </div>
</template>

<script>
// @ is an alias to /src
import { LockClosedIcon } from '@heroicons/vue/solid'
import Auth from '../services/auth'
import { ref } from 'vue'
import router from '../router/index.js'

export default {
  name: 'Home',
  components: {
    LockClosedIcon
  },
  setup() {

    if (localStorage.getItem('token') && localStorage.getItem('token') != undefined && localStorage.getItem('token') != "undefined"){
      router.push("home")
    }

    //setando para usar o toast
    const { toast } = require('tailwind-toast')

    const user = ref('')
    const password = ref('')

    function logar(event){
      event.preventDefault()

      startLoading()

      const usuario = {
        UserName: user.value,
        Password: password.value
      }

      Auth.login(usuario).then((resp) => {
          stopLoading()
          console.log(resp)
          localStorage.setItem('token', 'Bearer ' + (resp.data.token))
          router.push("home")
      }).catch(function (error) {
        if (error.response) {
          if (error.response.data.errors)
            toast()
              .default('Atenção:',error.response.data.errors[0].errorMessage)
              .with({
                shape: 'pill',
                duration: 3000,
                speed: 1000,
                positionX: 'end',
                positionY: 'top',
                color: 'bg-yellow-300',
                fontColor: 'white',
                fontTone: 200
              })
              .show()
          else
            toast()
              .default('Atenção: ', "'User Name' ou 'Passwor' incorretos")
              .with({
                shape: 'pill',
                duration: 3000,
                speed: 1000,
                positionX: 'end',
                positionY: 'top',
                color: 'bg-yellow-300',
                fontColor: 'white',
                fontTone: 200
              })
              .show()

          stopLoading()

        }
      })
    }

    //Setando Loadings
    const loading = ref(false)

    function startLoading(){
      loading.value = true
    }

    function stopLoading(){
      loading.value = false
    }

    return {
      logar, 
      user,
      password, 
      loading,
      startLoading,
      stopLoading
    } // qualquer dado retornado aqui estará disponível para o restante do componente
  }

}
</script>
