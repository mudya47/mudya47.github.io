import './App.css'
import LeftBar from './components/LeftBar.jsx'
import RightBar from './components/RightBar.jsx'
import Footer from './components/footer.jsx'

function App() {
  return (
    <>
      <div className="parent">
          <div class="div1">
            <LeftBar />
          </div>
          <div className="div2">
            <RightBar />
          </div>
      </div>
    </>
  )
}

export default App
