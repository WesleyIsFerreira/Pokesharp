<template>
    <nav
      class="relative w-full flex flex-wrap items-center justify-between py-3 bg-gray-900 text-gray-200 shadow-lg navbar navbar-expand-lg navbar-light"
    >
      <div class="container-fluid w-full flex flex-wrap items-center justify-between px-6">
        <button
          class="navbar-toggler text-gray-200 border-0 hover:shadow-none hover:no-underline py-2 px-2.5 bg-transparent focus:outline-none focus:ring-0 focus:shadow-none focus:no-underline"
          type="button"
          data-bs-toggle="collapse"
          data-bs-target="#navbarSupportedContent1"
          aria-controls="navbarSupportedContent"
          aria-expanded="false"
          aria-label="Toggle navigation"
        >
          <svg
            aria-hidden="true"
            focusable="false"
            data-prefix="fas"
            data-icon="bars"
            class="w-6"
            role="img"
            xmlns="http://www.w3.org/2000/svg"
            viewBox="0 0 448 512"
          >
            <path
              fill="currentColor"
              d="M16 132h416c8.837 0 16-7.163 16-16V76c0-8.837-7.163-16-16-16H16C7.163 60 0 67.163 0 76v40c0 8.837 7.163 16 16 16zm0 160h416c8.837 0 16-7.163 16-16v-40c0-8.837-7.163-16-16-16H16c-8.837 0-16 7.163-16 16v40c0 8.837 7.163 16 16 16zm0 160h416c8.837 0 16-7.163 16-16v-40c0-8.837-7.163-16-16-16H16c-8.837 0-16 7.163-16 16v40c0 8.837 7.163 16 16 16z"
            ></path>
          </svg>
        </button>
        <div class="collapse navbar-collapse flex-grow items-center" id="navbarSupportedContent1">
          <a class="text-xl pr-2 font-semibold" href="#">
            <img src="img/pokedex.png" class="w-24">
          </a>
          <!-- Left links -->
          <ul class="navbar-nav flex flex-col pl-0 list-style-none mr-auto">
            <li class="nav-item p-2">
              <a 
                :class="[page == 'Home' ? '' : 'opacity-60 hover:opacity-80 focus:opacity-80 p-0']"
                class="nav-link text-white" href="/home"
                >
                  Início
              </a>
            </li>
            <li class="nav-item p-2">
              <a
                :class="[page == 'Pokemons' ? '' : 'opacity-60 hover:opacity-80 focus:opacity-80 p-0']"
                class="nav-link text-white" href="/pokemons"
                >Pokémons</a
              >
            </li>
          </ul>
          <!-- Left links -->
        </div>
        <!-- Collapsible wrapper -->

        <!-- Right elements -->
        <div class="flex items-center relative">
          
          <div class="dropdown relative">
            <a
              class="dropdown-toggle flex items-center hidden-arrow"
              href="#"
              id="dropdownMenuButton2"
              role="button"
              data-bs-toggle="dropdown"
              aria-expanded="false"
            >
              <img
                src="img/professor.png"
                class="rounded-full"
                style="height: 35px; width: 35px"
                alt=""
                loading="lazy"
              />
            </a>
            <ul
              class="dropdown-menu min-w-max absolute bg-white text-base z-50 float-left py-2 list-none text-left rounded-lg shadow-lg mt-1 hidden m-0 bg-clip-padding border-none left-auto right-0"
              aria-labelledby="dropdownMenuButton2"
            >
              <li>
                <a
                  @click="logout" class="dropdown-item text-sm py-2 px-4 font-normal block w-full whitespace-nowrap bg-transparent text-gray-700 hover:bg-gray-100"
                  href="#"
                  >Sair</a
                >
              </li>
            </ul>
          </div>
        </div>
        <!-- Right elements -->
      </div>
    </nav>
</template>

<script>
import Auth from '../services/auth'

export default {
  name: 'NavBar',
  components: {
    
  },
  props: {
    page: String
  },
  setup() {

      function logout(){
        Auth.logout()
      }
      return{
          logout
      }
  }
}
</script>