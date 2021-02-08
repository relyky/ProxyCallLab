import React from "react"
import {BrowserRouter as Router,Switch,Route,Link} from "react-router-dom"
import Home from './Home'
import SimsProsyCall from './AppForms/SimsProxyCall'

export default function App() {
  return (
    <Router>
      <div>
        <nav>
          <ul>
            <li>
              <Link to="/">Home</Link>
            </li>
            <li>
              <Link to="/proxycall">SimsProsyCall</Link>
            </li>
          </ul>
        </nav>

        {/* A <Switch> looks through its children <Route>s and
            renders the first one that matches the current URL. */}
        <Switch>
          <Route path="/proxycall">
            <SimsProsyCall />
          </Route>
          <Route path="/">
            <Home />
          </Route>
        </Switch>
      </div>
    </Router>
  );
}
