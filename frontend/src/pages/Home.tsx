import React from "react";
import { Link } from "react-router-dom";

import herroBanner from "../assets/images/hero-banner.jpg";
import Helmet from "../components/Helmet";

const Home = () => {
  return (
    <Helmet title="Home">
      <section className="home">
        <div className="home__text">
          <h2 className="home__text__sub-header">Shop Smarter,</h2>
          <h1 className="home__text__header">Shop Hive</h1>
          <p className="home__text__description">
            Discover a buzzing ecommerce platform - Shop Hive: where endless
            choices meet seamless shopping. Join the hive today and elevate your
            online experience!
          </p>
          <Link to="/products" className="home__text__call-to-action">
            Shop now <i className="fa-solid fa-basket-shopping"></i>
          </Link>
        </div>
        <div className="home__hero-banner">
          <img src={herroBanner} alt="hero-banner" />
        </div>
      </section>
    </Helmet>
  );
};

export default Home;
