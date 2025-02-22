<template>
  <b-navbar toggleable="lg" type="dark">
    <!-- Brand -->
    <b-navbar-brand>
      <router-link to="/" :exact="true">
        <img
          class="img-fluid d-none d-md-block"
          src="@/assets/images/gov/bcid-logo-rev-en.svg"
          width="181"
          height="44"
          alt="B.C. Government Logo"
        />
        <img
          class="img-fluid d-md-none"
          src="@/assets/images/gov/bcid-symbol-rev.svg"
          width="64"
          height="44"
          alt="B.C. Government Logo"
        />
      </router-link>
    </b-navbar-brand>
    <b-navbar-brand>
      <h3>HealthGateway</h3>
    </b-navbar-brand>

    <b-navbar-toggle target="nav-collapse"></b-navbar-toggle>

    <!-- Navbar links -->
    <b-collapse id="nav-collapse" is-nav>
      <!-- Menu -->
      <b-navbar-nav v-if="displayMenu">
        <router-link class="nav-link" to="/home" :exact="true">
          <span class="fa fa-home"></span> Home
        </router-link>
        <router-link class="nav-link" to="/immunizations">
          <span class="fa fa-syringe"></span> Immunizations
        </router-link>
      </b-navbar-nav>

      <!-- Right aligned nav items -->
      <b-navbar-nav class="ml-auto">
        <b-nav-item-dropdown id="menuBtndUser" :text="greeting" v-if="isAuthenticated" right>
          <b-dropdown-item>
            <router-link id="menuBtnLogout" to="/logout" :exact="true">
              <span class="fa fa-user"></span> Logout
            </router-link>
          </b-dropdown-item>
        </b-nav-item-dropdown>
        <router-link id="menuBtnLogin" class="nav-link" to="/login" :exact="true" v-else>
          <span class="fa fa-user"></span> Login
        </router-link>
        <b-nav-item-dropdown id="languageSelector" :text="currentLanguage.description" right>
          <b-dropdown-text>Language:</b-dropdown-text>
          <b-dropdown-divider></b-dropdown-divider>
          <b-dropdown-item
            v-for="(value, key) in languages"
            :key="key"
            :active="currentLanguage.code === key"
          >
            <a :id="key" @click="onLanguageSelect(key)">{{value.description}}</a>
          </b-dropdown-item>
        </b-nav-item-dropdown>
      </b-navbar-nav>
    </b-collapse>
  </b-navbar>
</template>

<script lang="ts">
import Vue from "vue";
import { Prop, Component } from "vue-property-decorator";
import { State, Action, Getter } from "vuex-class";
import User from "@/models/user";

interface ILanguage {
  code: string;
  description: string;
}

const namespace: string = "auth";

@Component
export default class HeaderComponent extends Vue {
  @Getter("isAuthenticated", { namespace }) isAuthenticated: boolean;
  @Getter("authenticatedUser", { namespace }) authenticatedUser: User;

  languages: { [code: string]: ILanguage } = {};
  currentLanguage: ILanguage = null;

  created() {
    this.loadLanguages();
  }

  get displayMenu(): boolean {
    if (this.authenticatedUser != undefined && this.$route.path != "/") {
      return true;
    }

    return false;
  }

  get greeting(): string {
    if (this.authenticatedUser) {
      return "Hi " + this.authenticatedUser.name;
    } else {
      return "";
    }
  }

  onLanguageSelect(languageCode: string): void {
    this.currentLanguage = this.languages[languageCode];
  }

  loadLanguages(): void {
    this.languages["en"] = { code: "en", description: "English" };
    this.languages["fr"] = { code: "fr", description: "French" };
    this.currentLanguage = this.languages["en"];
  }
}
</script>