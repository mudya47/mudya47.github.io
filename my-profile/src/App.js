import './App.css';
import Content from './Content';
import Header from './Header';
import ToTop from './ToTop';

import './Content.css'

function App() {
  return (
    <div className="App">
      <header className="App-header">
        <Header />
      </header>
      <Content />
      <ToTop />
    </div>
  );
}

export default App;
