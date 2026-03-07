import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import Layout from './components/Layout/Layout';
import Listagem from './pages/Listagem/Listagem';
import Cadastro from './pages/Cadastro/Cadastro';

function App() {
  return (
    <Router>
      <Layout>
        <Routes>
          <Route path="/" element={<Listagem />} />
          <Route path="/novo" element={<Cadastro />} />
          <Route path="/editar/:id" element={<Cadastro />} />
        </Routes>
      </Layout>
    </Router>
  );
}

export default App;