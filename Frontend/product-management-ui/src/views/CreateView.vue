<script setup lang="ts">
import { onUpdated } from 'vue';
import { useRouter } from 'vue-router';

const router = useRouter();
</script>

<style>
</style>

<template>
    <q-page class="q-pa-md">
        <h1>CREATE ME</h1>
        <q-btn @click="router.back()">GO BACK</q-btn>
    </q-page>
</template>