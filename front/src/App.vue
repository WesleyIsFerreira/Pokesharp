<template>
<!--
  <div id="nav">
    <router-link to="/">Home</router-link> |
    <router-link to="/about">About</router-link>
  </div>
  -->
  <router-view/>
</template>

<style lang="postcss" >
    .btn-success {
        @apply  inline-block 
                px-6 py-2.5 
                bg-green-500 
                text-white 
                font-medium 
                text-xs 
                leading-tight 
                uppercase 
                rounded 
                shadow-md 
                hover:bg-green-600 hover:shadow-lg 
                focus:bg-green-600 focus:shadow-lg focus:outline-none focus:ring-0 
                transition duration-150 ease-in-out
    }
    .input-form {
      @apply  form-control
              block
              w-full
              px-2
              py-1
              text-sm
              font-normal
              text-gray-700
              bg-white bg-clip-padding
              border border-solid border-gray-300
              rounded
              transition
              ease-in-out
              mb-1
              focus:text-gray-700 focus:bg-white focus:border-blue-600 focus:outline-none
    }
    .label-form {
      @apply  inline-block 
              text-gray-700 
              text-sm
    }
    .select-form {
      @apply  form-select 
              appearance-none
              block
              w-full
              px-2
              py-1
              text-sm
              font-normal
              text-gray-700
              bg-white bg-clip-padding bg-no-repeat
              border border-solid border-gray-300
              rounded
              transition
              ease-in-out
              m-0
              focus:text-gray-700 focus:bg-white focus:border-blue-600 focus:outline-none
    }
    .z-100{
      z-index: 100;
    }
</style>
