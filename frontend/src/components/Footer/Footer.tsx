import React from 'react';
import { Github, Linkedin, MapPin } from 'lucide-react';
import './Footer.css';

const Footer: React.FC = () => {
  return (
    <footer className="main-footer">
      <div className="footer-container">
        <div className="footer-left">
          <div className="footer-logo">
            <MapPin size={20} />
            <span>Pontos Turísticos</span>
          </div>
          <p className="footer-description">
            Descubra e explore os melhores destinos turísticos do Brasil
          </p>
        </div>
        
        <div className="footer-center">
          <h4>Links Úteis</h4>
          <ul className="footer-links">
            <li><a href="/">Início</a></li>
            <li><a href="/novo">Cadastrar Ponto</a></li>
          </ul>
        </div>
        
        <div className="footer-right">
          <h4>Contato</h4>
          <p className="footer-contact">
            <Github size={18} style={{marginRight: "6px"}} />
            <a 
            href="https://github.com/douglas-felipe-mariano" 
            target="_blank" 
            rel="noopener noreferrer"
          >GitHub</a>
          </p>
          <p className="footer-contact">
            <Linkedin size={18} style={{marginRight: "6px"}} />
          <a 
            href="https://linkedin.com/in/douglasfelipemariano" 
            target="_blank" 
            rel="noopener noreferrer"
          >
            linkedin.com/in/seu-usuario
          </a>
          </p>
        </div>
      </div>
    </footer>
  );
};

export default Footer;