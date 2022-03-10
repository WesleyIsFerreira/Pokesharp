<template>
  <div class="bg-cover min-h-screen flex items-center justify-center py-12 px-4 sm:px-6 lg:px-8" style="background-image: url('img/bg.jpg')">
    <div class="max-w-md w-full space-y-8">
      <div>
        <img class="z-10 mx-auto h-20 rounded-full w-auto" src="img/Logo.png" alt="Workflow" />
        <h2 class="mt-6 text-center text-3xl font-extrabold text-gray-900">Área de testes</h2>
      </div>
      <form class="mt-8 space-y-6" action="#" method="POST">
        <input type="hidden" name="remember" value="true" />
        <div class="rounded-md shadow-sm -space-y-px">
          <div>
            <label for="user" class="sr-only">Usuário</label>
            <input v-model="user" id="user" name="user" type="text" autocomplete="off" required class="appearance-none rounded-none relative block w-full px-3 py-2 border border-gray-300 placeholder-gray-500 text-gray-900 rounded-t-md focus:outline-none focus:ring-indigo-500 focus:border-indigo-500 focus:z-10 sm:text-sm" placeholder="Usuário" />
          </div>
          <div>
            <label for="password" class="sr-only">Senha</label>
            <input v-model="password" id="password" name="password" type="password" autocomplete="current-password" required="" class="appearance-none rounded-none relative block w-full px-3 py-2 border border-gray-300 placeholder-gray-500 text-gray-900 rounded-b-md focus:outline-none focus:ring-indigo-500 focus:border-indigo-500 focus:z-10 sm:text-sm" placeholder="Senha" />
          </div>
        </div>
        <div>
          <button @click="logar" type="submit" class="group relative w-full flex justify-center py-2 px-4 border border-transparent text-sm font-medium rounded-md text-white bg-indigo-600 hover:bg-indigo-700 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-indigo-500">
            <span class="absolute left-0 inset-y-0 flex items-center pl-3">
              <LockClosedIcon class="h-5 w-5 text-indigo-500 group-hover:text-indigo-400" aria-hidden="true" />
            </span>
            Sign in
          </button>
        </div>
      </form>
    </div>
  </div>
</template>

<script>
// @ is an alias to /src
import { LockClosedIcon } from '@heroicons/vue/solid'
import Logins from '../services/login'
import { ref } from 'vue'

export default {
  name: 'Home',
  components: {
    LockClosedIcon
  },
  setup() {

    const user = ref('')
    const password = ref('')
    
    function logar(event){
      event.preventDefault()
      console.log(user.value)
      console.log(password.value)

      const usuario = {
        UserName: user.value,
        Password: password.value
      }

      console.log(usuario)

      Logins.login(usuario).then(resp => {
          console.log(resp)
      }).catch(function (error) {
        if (error.response) {
          console.log(error.response.data);
          console.log(error.response.status);
          console.log(error.response.headers);
        }
      })

    }

    
    return {logar, user, password} // qualquer dado retornado aqui estará disponível para o restante do componente
  }

}
</script>
