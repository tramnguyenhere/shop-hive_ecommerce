import React from "react";

import logo from "../assets/images/logo.png";
import nordeaLogo from "../assets/images/payment/nordea.png";
import opLogo from "../assets/images/payment/op.png";
import paypalLogo from "../assets/images/payment/paypal.png";

const Footer = () => {
  return (
    <footer className="footer">
      <section className="footer__section">
        <div className="footer__brand__logo">
          <img className="logo__image" src={logo} alt="logo" />
          <h5 className="footer__heading">Shop Hive</h5>
        </div>
        <p className="footer__brand__slogan">Shop Smarter, Shop Hive!</p>
      </section>
      <section className="footer__section">
        <h4 className="footer__heading">Contact</h4>
        <p>Customer Support Office: 124 Vuorikatu, Helsinki, Fi</p>
        <p>Hotline: +358 123 456 7899</p>
        <p>Email: support@shophive.com</p>
      </section>
      <section className="footer__section">
        <h4 className="footer__heading">Payment</h4>
        <div className="footer__section__content">
          <img className="footer__payment" src={nordeaLogo} alt="nordea" />
          <img className="footer__payment" src={opLogo} alt="op" />
          <img className="footer__payment" src={paypalLogo} alt="paypal" />
        </div>
      </section>
      <section className="footer__section">
        <h4 className="footer__heading">Follow us</h4>
        <div className="footer__section__content">
          <i className="fa-brands fa-facebook footer__icon"></i>
          <i className="fa-brands fa-instagram footer__icon"></i>
        </div>
      </section>
    </footer>
  );
};

export default Footer;
