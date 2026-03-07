import React from 'react';
import { MapPin } from 'lucide-react';
import './Header.css';

interface HeaderProps {
  title?: string;
  showNavigation?: boolean;
}

const Header: React.FC<HeaderProps> = ({ 
  title = "Sistema de Pontos Turísticos", 
  showNavigation = true 
}) => {
  return (
    <header className="main-header">
      <div className="header-container">
        <div className="header-left">
          <div className="logo">
            <MapPin size={32} className="logo-icon" />
            <h1 className="logo-text">{title}</h1>
          </div>
        </div>
        
        {showNavigation && (
          <nav className="header-nav">
            <a href="/" className="nav-link">
              <MapPin size={18} />
              Pontos Turísticos
            </a>
          </nav>
        )}
        
      </div>
    </header>
  );
};

export default Header;