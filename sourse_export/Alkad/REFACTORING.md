# GameWer refactoring map

This project was decompiled with obfuscated symbols such as `GClass4`, `GClass6`, and `smethod_0`. The source tree now uses functional folders and descriptive top-level type names while preserving the original control flow and runtime constants.

## Functional folders

- `Core/` - executable bootstrap, single-instance startup, settings, and isolated AppDomain startup.
- `Native/` - Win32 and PSAPI P/Invoke declarations and native error guards.
- `Injection/` - remote DLL loading strategies and injector options.
- `Detection/` - process/module monitoring, Steam session handling, inventory collection, screenshots, and report DTOs.
- `Network/` - WebSocket transport, cryptographic envelope helpers, hashing, time helpers, and server message DTOs.
- `Utils/` - logging, retry scheduling, consent/runtime guard checks, Discord presence, byte encoding, and protected string materialization.

## Important type renames

| Previous symbol | Current symbol | Responsibility |
| --- | --- | --- |
| `Class0` | `NativeMethods` | Kernel32/ntdll process, memory, and remote-thread interop. |
| `Class18` | `ProcessNativeMethods` | ToolHelp/PSAPI process enumeration interop. |
| `GClass0` | `DllInjector` | Coordinates SDK DLL loading into a target process. |
| `GClass4` | `RuntimeGuard` | Startup validation, consent checks, and main-loop dispatch. |
| `GClass6` | `ServerWebSocketClient` | Encrypted WebSocket communication with the server. |
| `GClass8` | `ModuleMonitor` | Local module discovery and SDK injection trigger. |
| `GClass30` | `ProcessModuleRegistry` | Process snapshot cache and module report queue. |
| `GClass33` | `SystemInventory` | Hardware, OS, registry, and network inventory collection. |

## Native interop cleanup

The most security-sensitive native constants are now named explicitly (for example, `ProcessAccessFlags.CreateThread`, `AllocationType.Commit`, `MemoryProtection.ExecuteReadWrite`, and `ProcessNativeMethods.SnapshotProcess`) instead of generic `flag_*` and `uint_*` names.
