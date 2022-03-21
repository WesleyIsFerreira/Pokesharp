<template>
  <div>
    <NavBarVue page="Home" />
    <div class="mx-2 bg-blue-200 rounded-md border-2 border-gray-500 mt-5 py-3">
      <div class="grid grid-cols-5">
        <div class="grid  col-span-3 content-center">
          <div class="w-fit px-4 sm:px-16">
            "Olá, bem vindo ao mundo POKÉMON! Este é um dos meus projetos pessoais em que estou criando um aparelho que chamo carinhosamente de POKEDEX, onde estou criando um cadastro com todos os pokémons estudados e os tipos de cada um."
          </div>
        </div>
        <div class="col-span-2">
          <img class="mx-auto" src="img/carvalho.png">
        </div>
      </div>
    </div>
  </div>
</template>

<script>
// @ is an alias to /src
import NavBarVue from "../components/NavBar.vue"

export default {
  name: 'Home',
  components: {
    NavBarVue
  }
}
</script>
