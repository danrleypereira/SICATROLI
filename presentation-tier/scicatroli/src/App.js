import './App.css';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';

//import components
import Home from './pages/home/Home';
import Genre from './pages/genre/Genre';
import Conservation from './pages/conservation/Conservation';

function App() {
  return (
    <Router>
      <Routes>
        <Route path="/" element={<Home />}/>
        <Route path="/genre" element={<Genre />}/>
        <Route path="/conservation" element={<Conservation />}/>
        <Route path='*' exact={true} element={<Home />}/>'
      </Routes>
    </Router>
  )
}

export default App;
